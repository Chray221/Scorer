using System;
using System.ComponentModel;
using System.Timers;
using System.Windows.Input;
using Scorer.Models;
using Xamarin.Forms;
using static Xamarin.Forms.Device;

namespace Scorer.VIewModel
{
    public class MainPageViewModel : BaseModel
    {

        int _Round = 1;
        public int Round
        {
            get { return _Round; }
            set { _Round = value; OnPropertyChanged(nameof(Round)); }
        }

        RoundScore _RoundScoreData;
        public RoundScore RoundScoreData
        {
            get { return _RoundScoreData; }
            set { _RoundScoreData = value; OnPropertyChanged(nameof(RoundScoreData)); }
        }

        RoundScore Round1 , Round2 , Round3;

        public ICommand BlueTeamPointsTapped { get; set; }

        public ICommand RedTeamPointsTapped { get; set; }

        public ICommand ResetTimerTapped { get; set; }

        public ICommand PlayStopTapped { get; set; }

        public ICommand RoundTapped { get; set; }

        Timer timer = new Timer(60000);

        bool _TimerStarting;
        public bool TimerStarting
        {
            get { return _TimerStarting; }
            set { _TimerStarting = value; OnPropertyChanged(nameof(TimerStarting)); }
        }

        /**/

        public MainPageViewModel()
        {
            OnRoundTapped_Executed("1");

            BlueTeamPointsTapped = new Command(OnBlueTeamPointsTapped_Executed);

            RedTeamPointsTapped = new Command(OnRedTeamPointsTapped_Executed);

            PlayStopTapped = new Command(OnPlayStopTapped);

            ResetTimerTapped = new Command(ResetTimerPointsTapped_Executed);
            RoundTapped = new Command(OnRoundTapped_Executed);
        }

        private void OnPlayStopTapped(object obj)
        {
            if (TimerStarting)
            {
                PauseTimer();
            }
            else
            {
                ContinueTimer();
            }
        }

        private void OnRoundTapped_Executed(object obj)
        {
            if (obj is string str)
            {
                int.TryParse(str, out int intValue);
                Round = intValue;
                switch(Round)
                {
                    case 1:
                        if(Round1 == null)
                            Round1 = new RoundScore();
                        RoundScoreData = Round1;
                        break;
                    case 2:

                        if (Round2 == null)
                            Round2 = new RoundScore();
                        RoundScoreData = Round2;
                        break;
                    case 3:

                        if (Round3 == null)
                            Round3 = new RoundScore();
                        RoundScoreData = Round3;
                        break;
                }

                PauseTimer();
            }
        }

        //void StartTimer()
        //{
        //    RoundScoreData.RemainingSec = 59;
        //    RoundScoreData.milliSecCounter = 0;
        //    if (!timerStarting)
        //    {
        //        ContinueTimer();
        //    }

        //    timerStarting = true;
        //}

        void StopTimer()
        {
            TimerStarting = false;
            RoundScoreData.RemainingSec = 59;
            RoundScoreData.milliSecCounter = 0;
        }

        void PauseTimer()
        {
            TimerStarting = false;
        }

        void ContinueTimer()
        {
            TimerStarting = true;
            Device.StartTimer(TimeSpan.FromMilliseconds(100),
(Func<bool>)(() =>
                    {
                        TimerChanged();
                        if (RoundScoreData.RemainingSec <= 0)
                            this.TimerStarting = false;
                        return (bool)this.TimerStarting;
                    }));
            
        }

        void TimerChanged()
        {
            switch (Round)
            {
                case 1://ROUND 1
                    Round1.milliSecCounter += 100;
                    if (Round1.milliSecCounter >= 1000)
                    {
                        Round1.milliSecCounter = 0;
                        Round1.RemainingSec--;
                    }
                    break;
                case 2://ROUND 2
                    Round2.milliSecCounter += 100;
                    if (RoundScoreData.milliSecCounter >= 1000)
                    {
                        Round2.milliSecCounter = 0;
                        Round2.RemainingSec--;
                    }
                    break;
                case 3://ROUND 3
                    Round3.milliSecCounter += 100;
                    if (RoundScoreData.milliSecCounter >= 1000)
                    {
                        Round3.milliSecCounter = 0;
                        Round3.RemainingSec--;
                    }
                    break;
            }
        }

        private void OnBlueTeamPointsTapped_Executed(object obj)
        {
            if (obj is string str)
            {
                switch(str)
                {
                    case "0": //POINTS
                        RoundScoreData.BlueTeamPoints++;
                        break;
                    case "1"://D
                        RoundScoreData.BlueTeamDPoints++;
                        break;
                    case "2"://F
                        RoundScoreData.BlueTeamFPoints++;
                        break;
                }
            }

        }

        private void OnRedTeamPointsTapped_Executed(object obj)
        {
            if (obj is string str)
            {
                switch (str)
                {
                    case "0"://POINTS
                        RoundScoreData.RedTeamPoints++;
                        break;
                    case "1"://D
                        RoundScoreData.RedTeamDPoints++;
                        break;
                    case "2"://F
                        RoundScoreData.RedTeamFPoints++;
                        break;
                }
            }

        }

        private void ResetTimerPointsTapped_Executed(object obj)
        {
            switch (Round)
            {
                case 1://POINTS
                    Round1 = new RoundScore();
                    RoundScoreData = Round1;
                    break;
                case 2://D

                    Round2 = new RoundScore();
                    RoundScoreData = Round2;
                    break;
                case 3://F
                    Round3 = new RoundScore();
                    RoundScoreData = Round3;
                    break;
            }

            StopTimer();
        }
    }
}
