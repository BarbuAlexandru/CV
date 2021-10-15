using HighwayTolls.Models;
using HighwayTolls.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HighwayTolls.Services
{
    public class StatsService
    {
        public List<MonthInfo> GetAllMonthInfoOfLocation(List<MonthInfo> monthInfo, List<TollPayment> tollPayments, List<TripPayment> tripPayments) {
            monthInfo = new List<MonthInfo>();

            foreach (var payment in tollPayments)
            {
                MonthInfo currentMonthInfo = monthInfo.Where(m => (m.year == payment.Date.Year && m.month == payment.Date.Month)).FirstOrDefault();
                if (currentMonthInfo == null)
                {
                    monthInfo.Add(new MonthInfo(payment.Date.Year, payment.Date.Month, payment.Amount));
                }
                else
                {
                    currentMonthInfo.income += payment.Amount;
                }
            }

            foreach (var payment in tripPayments)
            {
                MonthInfo currentMonthInfo = monthInfo.Where(m => (m.year == payment.Date.Year && m.month == payment.Date.Month)).FirstOrDefault();
                if (currentMonthInfo == null)
                {
                    monthInfo.Add(new MonthInfo(payment.Date.Year, payment.Date.Month, payment.Amount));
                }
                else
                {
                    currentMonthInfo.income += payment.Amount;
                }
            }

            // ;)
            monthInfo.Sort((x, y) => {
                int ret = x.year.CompareTo(y.year);
                return ret != 0 ? ret : x.month.CompareTo(y.month);
            });

            List<MonthInfo> auxMonthInfo = new List<MonthInfo>();
            MonthInfo lastMonth = null;
            foreach (var m in monthInfo)
            {
                if (lastMonth != null)
                {
                    if (!IsNext(lastMonth, m))
                    {
                        MonthInfo auxMonth = new MonthInfo(lastMonth);
                        auxMonth.income = 0;
                        while (!IsNext(auxMonth, m))
                        {
                            auxMonth.month += 1;
                            if (auxMonth.month > 12)
                            {
                                auxMonth.month = 1;
                                auxMonth.year += 1;
                            }

                            auxMonthInfo.Add(new MonthInfo(auxMonth));
                        }
                    }
                }
                lastMonth = new MonthInfo(m);
            }

            // all months or not
            monthInfo.AddRange(auxMonthInfo);
            monthInfo.Sort((x, y) => {
                int ret = x.year.CompareTo(y.year);
                return ret != 0 ? ret : x.month.CompareTo(y.month);
            });

            monthInfo.Reverse();
            return monthInfo;
        }

        private bool IsNext(MonthInfo m1Init, MonthInfo m2Init)
        {
            var m1 = new MonthInfo(m1Init);
            var m2 = new MonthInfo(m2Init);
            m1.month += 1;
            if (m1.month > 12)
            {
                m1.month = 1;
                m1.year += 1;
            }

            if (m1.month == m2.month && m1.year == m2.year)
            {
                return true;
            }
            return false;
        }
    }
}
