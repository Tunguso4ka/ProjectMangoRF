using System;
using System.IO;
using System.Windows;
using System.Windows.Media;

namespace ProjectMangoRF
{
    class MusicLogic
    {
        Random random = new Random();
        MediaPlayer mediaPlayer = new MediaPlayer();

        public void CreateMediaPlayer()
        {
            mediaPlayer.MediaEnded += PlayerMediaEnded;
        }
        public void Play()
        {
            if (Properties.Settings.Default.MusicVolume != 0)
            {
                //MessageBox.Show("0");
                string MusicPath = "";
                MusicPath = GetMusicPath(Environment.CurrentDirectory + "/music");
                if (MusicPath != "")
                {
                    mediaPlayer.Open(new Uri(MusicPath));
                    mediaPlayer.Volume = Properties.Settings.Default.MusicVolume;
                    mediaPlayer.Play();
                }
            }
        }

        string GetMusicPath (string FolderPath)
        {
            if (Directory.Exists(FolderPath))
            {
                string[] Songs = Directory.GetFiles(FolderPath, "*.mp3");
                return Songs[random.Next(0, Songs.Length)];
            }
            else
            {
                return "";
            }
        }

        private void PlayerMediaEnded (object sender, EventArgs e)
        {
            Play();
        }
    }
}
