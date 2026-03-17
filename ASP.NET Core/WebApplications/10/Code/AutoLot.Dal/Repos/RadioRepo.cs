// Copyright Information
// ==================================
// AutoLot-Temp - AutoLot.Dal - RadioRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/23
// ==================================

namespace AutoLot.Dal.Repos;

public class RadioRepo : TemporalTableBaseRepo<Radio>, IRadioRepo
{
    public RadioRepo(ApplicationDbContext context) : base(context) { }
    internal RadioRepo(DbContextOptions<ApplicationDbContext> options) : base(options) { }
}
