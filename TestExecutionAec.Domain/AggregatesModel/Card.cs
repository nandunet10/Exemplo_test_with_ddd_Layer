﻿namespace TestExecutionAec.Domain.AggregatesModel
{
    public class Card
    {
        public Guid CardId { get; set; }
        public string? Titulo { get; set; }
        public string? Area { get; set; }
        public string? Autor { get; set; }
        public string? Descricao { get; set; }
        public string? DataPublicacao { get; set; }

    }
}
