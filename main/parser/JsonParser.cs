using main.dto;
using main.events;
using main.payload;
using main.request;
using main.response;
using System.Text.Json;

namespace main.parser
{
    public class JsonParser
    {
        private static readonly JsonSerializerOptions SerializeOptions = new()
        {
            WriteIndented = true,
            Converters =
            {
                new EnumConverter<RequestType>(),
                new EnumConverter<PayloadType>(),
                new EnumConverter<ResponseStatus>(),
                new EnumConverter<EventType>(),
                new EnumConverter<GameType>(),
                new EnumConverter<City>(),
                new DateTimeConverter()
            }
        };

        public static string ParseToString<T>(T t)
        {
            return JsonSerializer.Serialize(t, SerializeOptions);
        }

        public static Request ParseToRequest(string requestJson)
        {
            Request request = JsonSerializer.Deserialize<Request>(requestJson, SerializeOptions)!;
            request.Payload = ParsePayload(request.Payload);
            return request;
        }

        public static Response ParseToResponse(string responseJson)
        {
            Response response = JsonSerializer.Deserialize<Response>(responseJson, SerializeOptions)!;
            response.Payload = ParsePayload(response.Payload);
            return response;
        }

        public static Event ParseToEvent(string eventJson)
        {
            Event _event = JsonSerializer.Deserialize<Event>(eventJson, SerializeOptions)!;
            _event.Payload = ParsePayload(_event.Payload);
            return _event;
        }

        private static Payload ParsePayload(Payload payload)
        {
            if (payload == null)
            {
                return payload;
            }
            var jsonElement = (JsonElement)payload.Data;
            payload.Data = payload.Type switch
            {
                PayloadType.User => jsonElement.Deserialize<UserDto>(SerializeOptions),
                PayloadType.Games => DeserializeArray<GameDto>(jsonElement),
                PayloadType.String => jsonElement.Deserialize<string>(SerializeOptions),
                PayloadType.SoldTicket => jsonElement.Deserialize<SoldTicketDto>(SerializeOptions)
            };
            return payload;
        }

        private static List<T> DeserializeArray<T>(JsonElement jsonElement)
        {
            List<T> objects = new List<T>();
            foreach (var element in jsonElement.EnumerateArray())
            {
                T obj = JsonSerializer.Deserialize<T>(element.GetRawText(), SerializeOptions);
                objects.Add(obj);
            }
            return objects;
        }
    }
}
