namespace OnlinePharmacy.Client.Static
{
    public static class Endpoints
    {
        private static readonly string Prefix = "api";

        public static readonly string ProductsEndpoint = $"{Prefix}/products";
        public static readonly string AppointmentsEndpoint = $"{Prefix}/appointments";
<<<<<<< HEAD
        //public static readonly string ColoursEndpoint = $"{Prefix}/colours";
        public static readonly string OrdersEndpoint = $"{Prefix}/orders";
=======
        public static readonly string PrescriptionsEndpoint = $"{Prefix}/prescriptions";
        public static readonly string OrdersEndpoint = $"{Prefix}/orders";
        //public static readonly string VehiclesEndpoint = $"{Prefix}/vehicles";
>>>>>>> eeb47891e9cd10e0229b2283ae851107716e694f
        //public static readonly string CustomersEndpoint = $"{Prefix}/customers";
        //public static readonly string BookingsEndpoint = $"{Prefix}/bookings";
    }
}
