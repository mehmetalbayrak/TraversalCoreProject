﻿using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalRApiMSSql.DataAccess;
using SignalRApiMSSql.Hubs;

namespace SignalRApiMSSql.Models
{
    public class VisitorService
    {
        private readonly Context _context;
        private readonly IHubContext<VisitorHub> _hubContext;

        public VisitorService(Context context, IHubContext<VisitorHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }
        public IQueryable<Visitor> GetList()
        {
            return _context.Visitors.AsQueryable();
        }
        public async Task SaveVisitor(Visitor visitor)
        {
            await _context.Visitors.AddAsync(visitor);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("CallVisitorList", GetVisitorChartList());
        }
        public List<VisitorChart> GetVisitorChartList()
        {
            List<VisitorChart> visitorCharts = new List<VisitorChart>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "select tarih, [1],[2],[3],[4],[5] from (select [City],VisitCount,Cast([VisitDate] as Date) as tarih from Visitors) as visitTable Pivot (Sum(VisitCount) for City in([1],[2],[3],[4],[5])) as pivottable order by tarih desc";
                command.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        VisitorChart visitorChart = new VisitorChart();
                        visitorChart.VisitDate = reader.GetDateTime(0).ToShortDateString();
                        Enumerable.Range(1, 5).ToList().ForEach(x =>
                        {
                            if (DBNull.Value.Equals(reader[x]))
                            {
                                visitorChart.Counts.Add(0);
                            }
                            else
                            {
                                visitorChart.Counts.Add(reader.GetInt32(x));
                            }
                        });
                        visitorCharts.Add(visitorChart);
                    }
                }
                _context.Database.CloseConnection();
            }
            return visitorCharts;

        }
    }
}
