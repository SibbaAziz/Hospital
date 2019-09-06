using System.ComponentModel;

namespace Hospital.Wpf.Helpers
{

    enum JobEnum
    {
        [Description("Directeur")]
        Directeur,
        [Description("Médecin Spécialiste")]
        MedecinSpecialiste,
        [Description("Médecin généraliste")]
        MedecinGeneraliste,
        [Description("Sage-femme")]
        SageFemme,


    } 
}
