using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Newtonsoft.Json;

using SoftJail.Data.Models;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportPrisonerDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [Required]
        [RegularExpression(@"(The\s)([A-Z][a-z]+)")]
        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        [Required]
        [Range(18, 65)]
        [JsonProperty("age")]
        public int Age { get; set; }

        [Required]
        [JsonProperty("incarcerationDate")]
        public string IncarcerationDate { get; set; }

        [JsonProperty("releaseDate")]
        public string ReleaseDate { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        [JsonProperty("bail")]
        public decimal? Bail { get; set; }

        [JsonProperty("cellId")]
        public int? CellId { get; set; }

        [JsonProperty("mails")]
        public ImportMailDto[] Mails { get; set; }
    }
}
