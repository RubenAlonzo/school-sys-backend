namespace SchoolSystem.Api
{
    internal static class ApiEndpoints
    {
        private const string Root = "/api";

        internal static class Rooms
        {
            private const string Base = $"{Root}/rooms";

            internal const string Create = $"{Base}";
            internal const string Get = $"{Base}/{{id}}";
            internal const string GetAll = $"{Base}/";
            internal const string Update = $"{Base}/{{id}}";
            internal const string Delete = $"{Base}/{{id}}";
        }
        
        internal static class Schedule
        {
            private const string Base = $"{Root}/schedules";

            internal const string Create = $"{Base}";
            internal const string Get = $"{Base}/{{id}}";
            internal const string GetAll = $"{Base}/";
            internal const string Update = $"{Base}/{{id}}";
            internal const string Delete = $"{Base}/{{id}}";
        }

        internal static class Users
        {
            private const string Base = $"{Root}/users";

            internal static class Students
            {
                private const string Base = $"{Root}/users/students";

                internal const string Create = $"{Base}";
                internal const string Get = $"{Base}/{{id}}";
                internal const string GetAll = $"{Base}/";
                internal const string Update = $"{Base}/{{id}}";
                internal const string Delete = $"{Base}/{{id}}";
            }

            internal static class Teachers
            {
                private const string Base = $"{Root}/users/teachers";

                internal const string Create = $"{Base}";
                internal const string Get = $"{Base}/{{id}}";
                internal const string GetAll = $"{Base}/";
                internal const string Update = $"{Base}/{{id}}";
                internal const string Delete = $"{Base}/{{id}}";
            }
        }
    }
}
