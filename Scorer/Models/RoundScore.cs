using System;
namespace Scorer.Models
{
    public class RoundScore : BaseModel
    {
        int _BlueTeamPoints;
        public int BlueTeamPoints
        {
            get { return _BlueTeamPoints; }
            set { _BlueTeamPoints = value; OnPropertyChanged(nameof(BlueTeamPoints)); }
        }

        int _BlueTeamDPoints;
        public int BlueTeamDPoints
        {
            get { return _BlueTeamDPoints; }
            set { _BlueTeamDPoints = value; OnPropertyChanged(nameof(BlueTeamDPoints)); }
        }

        int _BlueTeamFPoints;
        public int BlueTeamFPoints
        {
            get { return _BlueTeamFPoints; }
            set { _BlueTeamFPoints = value; OnPropertyChanged(nameof(BlueTeamFPoints)); }
        }

        int _RedTeamPoints;
        public int RedTeamPoints
        {
            get { return _RedTeamPoints; }
            set { _RedTeamPoints = value; OnPropertyChanged(nameof(RedTeamPoints)); }
        }

        int _RedTeamDPoints;
        public int RedTeamDPoints
        {
            get { return _RedTeamDPoints; }
            set { _RedTeamDPoints = value; OnPropertyChanged(nameof(RedTeamDPoints)); }
        }

        int _RedTeamFPoints;
        public int RedTeamFPoints
        {
            get { return _RedTeamFPoints; }
            set { _RedTeamFPoints = value; OnPropertyChanged(nameof(RedTeamFPoints)); }
        }

        int _RemainingSec;
        public int RemainingSec
        {
            get { return _RemainingSec; }
            set { _RemainingSec = value; OnPropertyChanged(nameof(RemainingSec));  OnPropertyChanged(nameof(TimerString)); }
        }

        public string TimerString { get { return $"{RemainingSec / 60} : {(RemainingSec % 60).ToString("##")}"; } }

        public int milliSecCounter = 0;

        public RoundScore()
        {
            RemainingSec = 59;
        }
    }
}
