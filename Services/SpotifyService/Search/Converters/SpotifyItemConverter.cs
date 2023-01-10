﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SpotifyPlus.Services.Search;
using SpotifyPlus.Services.SpotifyService.Search;

namespace SpotifyPlus.Services.Converters
{
    public class SearchItemConverter : JsonConverter<SpotifySearchItemBase>
    {
        public override SpotifySearchItemBase? ReadJson(JsonReader reader, Type objectType, SpotifySearchItemBase? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            var item = Create(objectType, jObject);
            return item; ;
        }

        public override void WriteJson(JsonWriter writer, SpotifySearchItemBase? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        private SpotifySearchItemBase Create(Type objectType, JObject jObject)
        {
            var searchItem = jObject.ToObject<SpotifySearchItemBase>();
            if(searchItem.Type == SpotifyItemType.album)
            {
                return jObject.ToObject<SpotifySearchItemAlbum>();
            }
            return null;
        }
    }
}
