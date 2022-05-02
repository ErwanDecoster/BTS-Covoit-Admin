using System;
using System.Collections.Generic;

#nullable disable

namespace CovoitAdmin2.Model
{
    public partial class VillesFranceFree
    {
        public int VilleId { get; set; }
        public string VilleDepartement { get; set; }
        public string VilleSlug { get; set; }
        public string VilleNom { get; set; }
        public string VilleNomSimple { get; set; }
        public string VilleNomReel { get; set; }
        public string VilleNomSoundex { get; set; }
        public string VilleNomMetaphone { get; set; }
        public string VilleCodePostal { get; set; }
        public string VilleCommune { get; set; }
        public string VilleCodeCommune { get; set; }
        public short? VilleArrondissement { get; set; }
        public string VilleCanton { get; set; }
        public short? VilleAmdi { get; set; }
        public int? VillePopulation2010 { get; set; }
        public int? VillePopulation1999 { get; set; }
        public int? VillePopulation2012 { get; set; }
        public int? VilleDensite2010 { get; set; }
        public float? VilleSurface { get; set; }
        public float? VilleLongitudeDeg { get; set; }
        public float? VilleLatitudeDeg { get; set; }
        public string VilleLongitudeGrd { get; set; }
        public string VilleLatitudeGrd { get; set; }
        public string VilleLongitudeDms { get; set; }
        public string VilleLatitudeDms { get; set; }
        public int? VilleZmin { get; set; }
        public int? VilleZmax { get; set; }
    }
}
