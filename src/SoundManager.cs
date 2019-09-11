using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Kazaam.Audio {
  public static class SoundManager {
    public static void SetSoundEffectVolume(float volume) {
      if (volume > 1.0f) {
        volume = 1.0f;
      } else if (volume < 0.0f) {
        volume = 0.0f;
      }

      SoundEffect.MasterVolume = volume;
    }

    public static float GetSoundEffectVolume() {
      return SoundEffect.MasterVolume;
    }

    public static void SetMusicVolume(float volume) {
      if (volume > 1.0f) {
        volume = 1.0f;
      } else if (volume < 0.0f) {
        volume = 0.0f;
      }

      MediaPlayer.Volume = volume;
    }

    public static float GetMusicVolume() {
      return MediaPlayer.Volume;
    }

    public static void ToggleMusic() {
      if (MediaPlayer.State == MediaState.Playing) {
        MediaPlayer.Pause();
      } else if (MediaPlayer.State == MediaState.Paused) {
        MediaPlayer.Resume();
      }
    }
  }
}
