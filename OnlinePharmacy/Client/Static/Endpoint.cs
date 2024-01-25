namespace OnlinePharmacy.Client.Static
{
    public static class Endpoints
    {
        private static readonly string Prefix = "api";

        public static readonly string ProductsEndpoint = $"{Prefix}/products";
        public static readonly string AppointmentsEndpoint = $"{Prefix}/appointments";
        //public static readonly string ColoursEndpoint = $"{Prefix}/colours";
        public static readonly string PrescriptionsEndpoint = $"{Prefix}/prescriptions";
        public static readonly string OrdersEndpoint = $"{Prefix}/orders";
        public static readonly string UsersEndpoint = $"{Prefix}/users";
        //public static readonly string CustomersEndpoint = $"{Prefix}/customers";
        //public static readonly string BookingsEndpoint = $"{Prefix}/bookings";
    }
}
