using System.ComponentModel;

namespace PlataformaRedencao.Domain.Enums
{
    /// <summary>
    /// Defines education levels.
    /// </summary>
    public enum EducationLevel
    {
        [Description("Illiterate")]
        Illiterate = 0,

        [Description("Elementary school completed")]
        ElementarySchoolCompleted = 1,

        [Description("Elementary school incomplete")]
        ElementarySchoolIncomplete = 2,

        [Description("High school completed")]
        HighSchoolCompleted = 3,

        [Description("High school incomplete")]
        HighSchoolIncomplete = 4,

        [Description("Higher education completed")]
        HigherEducationCompleted = 5,

        [Description("Higher education incomplete")]
        HigherEducationIncomplete = 6,

        [Description("Postgraduate")]
        Postgraduate = 7,

        [Description("Master's degree")]
        MasterDegree = 8,

        [Description("Doctorate")]
        Doctorate = 9
    }
}
