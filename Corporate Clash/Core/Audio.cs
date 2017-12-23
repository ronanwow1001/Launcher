using System;
using System.Media;

namespace CorporateClash.Core
{
	public static class Audio
	{
	    public const string Click = "sndclick";

		public static void PlaySoundFile(string filename)
		{
			try
			{
				if (!Settings.Instance.WantClickSound) return;

                // Search for the sound
                var sound = Properties.Resources.ResourceManager.GetStream(filename);

                // Play sound
			    Log.Info($"Playing {filename}");
			    new SoundPlayer(sound).Play();
            }
            catch (Exception ex)
			{
				Log.Error($"Unable to play audio: {filename}");
				Log.Error(ex);
			}
		}
	}
}
