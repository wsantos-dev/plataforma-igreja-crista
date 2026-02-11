using System.ComponentModel;

namespace PlataformaRedencao.Domain.Enums
{
    /// <summary>
    /// Define os níveis de escolaridade.
    /// </summary>
    public enum EducationLevel
    {
        [Description("Analfabeto(a)")]
        Illiterate = 0,

        [Description("Ensino Fundamental Completo")]
        ElementarySchoolCompleted = 1,

        [Description("Ensino Fundamental Incompleto")]
        ElementarySchoolIncomplete = 2,

        [Description("Ensino Médio Completo")]
        HighSchoolCompleted = 3,

        [Description("Ensino Médio Incompleto")]
        HighSchoolIncomplete = 4,

        [Description("Superior Completo")]
        HigherEducationCompleted = 5,

        [Description("Superior Incompleto")]
        HigherEducationIncomplete = 6,

        [Description("Pós-Graduação")]
        Postgraduate = 7,

        [Description("Mestrado")]
        MasterDegree = 8,

        [Description("Doutorado")]
        Doctorate = 9
    }
}
