using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Kazaam.Audio {
  public class Music : ISound  {
    private Song song;

    public Music(Song song) {
      this.song = song;
    }

    public void Play() {
      MediaPlayer.Play(song);
    }

    public void Pause() {
      MediaPlayer.Pause();
    }

    public void Stop() {
      MediaPlayer.Stop();
    }
  }
}
