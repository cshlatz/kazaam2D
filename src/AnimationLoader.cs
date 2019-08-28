//-----------------------------------------------------------------------------
// Animation.cs
//
// Kazaam Simple Game Engine
// Copyright (C) Connor Shlatz. All rights reserved.
//-----------------------------------------------------------------------------

using Kazaam.Animate;

using Microsoft.Xna.Framework;

using Newtonsoft.Json;

using System;
using System.IO;
using System.Collections.Generic;

namespace Kazaam.Assets {
  public class AseSpritesheet {
    [JsonProperty("frames")]
    public List<AseFrames> Frames {get; set;}

    [JsonProperty("meta")]
    public AseMeta Meta {get; set;}
  }

  public class AseFrames {
    public AseFrame Frame {get; set;}

    [JsonProperty("duration")]
    public int Duration {get; set;}
  }

  public class AseFrame {
    [JsonProperty("x")]
    public int X {get; set;}

    [JsonProperty("y")]
    public int Y {get; set;}

    [JsonProperty("w")]
    public int W {get; set;}

    [JsonProperty("h")]
    public int H {get; set;}
  }

  public class AseMeta {
    [JsonProperty("frameTags")]
    public List<AseMetaFrame> FrameTags {get; set;}
  }

  public class AseFrameTags {
    public List<AseMetaFrame> Frames;
  }

  public class AseMetaFrame {
    [JsonProperty("name")]
    public string Name {get; set;}

    [JsonProperty("from")]
    public int From {get; set;}

    [JsonProperty("to")]
    public int To {get; set;}
  }

  
  /// <summary>
  /// Loads an Aseprite generated JSON animation file and turns them into fully built Animation objects.
  /// </summary>
  public class AnimationLoader : ITypeLoader {
    public object Load(Stream assetStream) {
      var animations = new Dictionary<string, Animation>();
      AseSpritesheet spritesheet;
      AseMeta meta;
      string json;
      using (var sr = new StreamReader(assetStream)) {
        json = sr.ReadToEnd();
      }
      spritesheet = JsonConvert.DeserializeObject<AseSpritesheet>(json);
      meta = spritesheet.Meta;

      foreach (AseMetaFrame frame in meta.FrameTags) {
        int index = 0;
        var animation = new Animation();
        foreach (AseFrames frames in spritesheet.Frames) {
          index++;
          if (index >= frame.From && index <= frame.To) {
            var rect = new Rectangle(frames.Frame.X, frames.Frame.Y, frames.Frame.W, frames.Frame.H);
            animation.AddFrame(rect, TimeSpan.FromMilliseconds(frames.Duration));
          }
        }
        animations.Add(frame.Name, animation);
      }
      return animations;
    }
  }
}
