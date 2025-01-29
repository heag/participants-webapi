using Hector.Data;
using Hector.Models.DTOs;

namespace Hector.Repositories
{
    public class JobRepository
        
    {
        private readonly HectorDbContext _jobDbContext;

        public JobRepository(HectorDbContext jobDbContext)
        {
            _jobDbContext = jobDbContext;
        }

        public List<JobDTO> GetAllJobs() => _jobDbContext.Jobs.ToList();
        public List<JobDTO> GetJobs(int count) => _jobDbContext.Jobs.Take(count).ToList();
        public JobDTO GetJob(string id) => _jobDbContext.Jobs.FirstOrDefault(i => i.Id == id);

        public JobDTO CreateJob(JobDTO job)
        {
            int? maxJobId = Int32.Parse(_jobDbContext.Jobs.Max(i => i.Id));
            maxJobId = maxJobId.HasValue ? maxJobId.Value : 0;
            job.Id = (maxJobId + 1).ToString();
            _jobDbContext.Jobs.Add(job);
            _jobDbContext.SaveChanges();
            return job;
        }

        public JobDTO UpdateJob(string id, JobDTO job)
        {
            var existingJob = _jobDbContext.Jobs.FirstOrDefault(i => i.Id == id);
            if (existingJob != null)
            {
                existingJob.Title = job.Title;
                existingJob.Type = job.Type;
                existingJob.Location = job.Location;
                existingJob.Salary = job.Salary;
                existingJob.Description = job.Description;
            }
            _jobDbContext.SaveChanges();
            return existingJob;
        }

        public bool DeleteJob(string id)
        {
            var job = _jobDbContext.Jobs.FirstOrDefault(i => i.Id == id);
            if (job != null)
            {
                _jobDbContext.Jobs.Remove(job);
                _jobDbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
