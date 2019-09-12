using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;

namespace Hospital.Wpf.Helpers
{


    public class EnumExtension
    {
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }

        public static Enum GetEnumByDescription(Type type, string description)
        {
            var values = Enum.GetValues(type);
            foreach (var value in values)
            {
                if (description == GetEnumDescription((Enum)value))
                    return (Enum)value;
            }

            return null;
        }

    }

    enum JobEnum
    {
        [Description("Directeur")]
        Directeur,
        [Description("Chef de service")]
        ChefDeService,
        [Description("Médecin Spécialiste")]
        MedecinSpecialiste,
        [Description("Médecin généraliste")]
        MedecinGeneraliste,
        [Description("Sage-femme")]
        SageFemme,
        [Description("Infirmier")]
        Infirmier,
        [Description("Technicien de surface")]
        TechnicienDeSurface,
        [Description("Agent de sécurité")]
        AgentDeSecurite,
        [Description("Secrétaire")]
        Secretaire,
        [Description("Administrateur")]
        Administrateur,
        [Description("Agent technique")]
        AgentTechnique,
        [Description("Agent administratif")]
        AgentAdministratif,
        [Description("Agent d’hygiène")]
        AgentHygiene
    } 
}
