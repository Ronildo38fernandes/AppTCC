using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTCC.Models
{
    public class Regiao
    {
        public int Id {  get; set; }

        public string Sigla { get; set; }
        public string Nome { get; set; } 
    }
    public class UF 
    {
        public int Id { get; set; }

        public string Sigla { get; set; }

        public string Nome { get; set; }

        public Regiao Regiao { get; set; }
    }

    public class Mesorregiao
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public UF Uf { get; set; }
    }

    public class Microrregiao 
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public Mesorregiao Mesorregiao { get; set; }
    }
    public class Municipios
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public Microrregiao Microrregiao { get; set;}


        public static List<Municipios> BuscarMunicipios(string estado) 
        {
            string url = $"https://servicodados.ibge.gov.br/api/v1/localidades/estados/{estado}/municipios";
                //"https://servicodados.ibge.gov.br/api/v1/localidades/municipios";

            string json = (new System.Net.WebClient()).DownloadString(url);

            var mun = JsonConvert.DeserializeObject<List<Municipios>>(json);

            return mun;
        }
    }

    


}
