using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PM2EX201730110111.Modelos
{
    public class Localizacion
    {
        [PrimaryKey, AutoIncrement]
        public int L_ID { get; set; }

        [MaxLength(100)]
        public string L_Latitud { get; set; }

        [MaxLength(100)]
        public string L_Longitud { get; set; }

        [MaxLength(250)]
        public string L_Descripcion { get; set; }

        [MaxLength(250)]
        public string L_Desc_Corta { get; set; }

    }
}
