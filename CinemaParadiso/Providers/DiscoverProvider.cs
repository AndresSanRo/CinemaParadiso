using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaParadiso.Providers
{
    public enum Sort
    {
        PopularityAsc = 0,
        PopularityDesc = 1,
        ReleaseDateAsc = 2,
        ReleaseDateDesc = 3,
        RevenueAsc = 4,
        RevenueDesc = 5,
        PrimaryReleaseDateAsc = 6,
        PrimaryReleaseDateDesc = 7,
        OriginalTitleAsc = 8,
        OriginalTitleDesc = 9,
        VoteAverageAsc = 10,
        VoteAverageDesc = 11,
        VoteCountAsc = 12,
        VoteCountDesc = 13
    }
    public enum IncludeAdult
    {
        Yes = 0,
        No =1
    }
    public static class DiscoverProvider
    {
        public static String AdultMovies(IncludeAdult options)
        {
            String adult = "";
            switch (options)
            {
                case IncludeAdult.Yes:
                    adult = "Yes";
                    break;
                case IncludeAdult.No:
                    adult = "No";
                    break;
            }
            return adult;
        }
        public static String SortBy(Sort sortType)
        {
            String sortMethod = "";
            switch (sortType)
            {
                case Sort.OriginalTitleAsc:
                    sortMethod = "original_title.asc";
                    break;
                case Sort.OriginalTitleDesc:
                    sortMethod = "original_title.desc";
                    break;
                case Sort.PopularityAsc:
                    sortMethod = "populariry.asc";
                    break;
                case Sort.PopularityDesc:
                    sortMethod = "popularity.desc";
                    break;
                case Sort.PrimaryReleaseDateAsc:
                    sortMethod = "primary_release_date.asc";
                    break;
                case Sort.PrimaryReleaseDateDesc:
                    sortMethod = "primary_release_date.desc";
                    break;
                case Sort.ReleaseDateAsc:
                    sortMethod = "release_date.asc";
                    break;
                case Sort.ReleaseDateDesc:
                    sortMethod = "release_date.desc";
                    break;
                case Sort.RevenueAsc:
                    sortMethod = "revenue.asc";
                    break;
                case Sort.RevenueDesc:
                    sortMethod = "revenue.desc";
                    break;
                case Sort.VoteAverageAsc:
                    sortMethod = "vote_average.asc";
                    break;
                case Sort.VoteAverageDesc:
                    sortMethod = "vote_average.desc";
                    break;
                case Sort.VoteCountAsc:
                    sortMethod = "vote_count.asc";
                    break;
                case Sort.VoteCountDesc:
                    sortMethod = "vote.count.desc";
                    break;
            }
            return sortMethod;
        }
    }
}
