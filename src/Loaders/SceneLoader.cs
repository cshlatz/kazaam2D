using Kazaam.System;

using Newtonsoft.Json;

using System.IO;
using System.Collections.Generic;

namespace Kazaam.Assets {
    /// <summary>
    /// Loads a scene from a JSON file
    /// </summary>
    public class SceneLoader : ITypeLoader {
        public class SceneJson {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("content")]
            public List<IContent> Content { get; set; }

            [JsonProperty("entities")]
            public List<IEntity> Entities { get; set; }
        }

        public object Load(Stream assetStream) {
            Scene scene = new Scene();

            // Deserialize the scene from the json file
            string json;
            using (var sr = new StreamReader(assetStream)) {
              json = sr.ReadToEnd();
            }
            SceneJson scene = JsonConvert.DeserializeObject<SceneJson>(json);

            // Load the map
            MapLoader = new MapLoader();
            try {
                scene.Map = 
            } catch {
            }
            return scene;
        }
    }
}
