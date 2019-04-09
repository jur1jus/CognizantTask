using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dal.ViewModels;

namespace Services
{
	public interface ITaskService : IBaseService
	{
	}

    public class TaskService : BaseService, ITaskService
    {
		public TaskService(CognizantDataContext dbContext)
			: base(dbContext)
		{

		}
	}
}
