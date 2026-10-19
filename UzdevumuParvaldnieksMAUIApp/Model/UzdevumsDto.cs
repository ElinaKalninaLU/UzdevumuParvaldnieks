using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace UzdevumuParvaldnieksMAUIApp.Model
{
    public class UzdevumsDto
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("nosaukums")]
        public string Nosaukums { get; set; }
        [JsonPropertyName("apraksts")]
        public string Apraksts { get; set; }
        public UzdevumsDto() { }
        public UzdevumsDto(int id, string nosaukums, string apraksts)
        {
            ID = id;
            Nosaukums = nosaukums;
            Apraksts = apraksts;
        }
    }
}
