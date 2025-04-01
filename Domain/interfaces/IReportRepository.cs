using aztro_cchardos_back_group2.Domain.Entities;

namespace aztro_cchardos_back_group2.Domain.Interfaces
{
    public interface IReportRepository
    {
        Task<List<AnswerEntity>> GetAnswersByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<List<AnswerEntity>> GetAnswersByCategoryAsync(string category);
        Task<List<CombinationEntity>> GetDestinationStatisticsAsync();
        Task<List<UserEntity>> GetUserActivityStatisticsAsync();
        Task<List<AnswerEntity>> GetAllAnswersWithDetailsAsync();
    }
}