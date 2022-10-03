namespace Controller.Models
{
    public class ParkingContract
    {
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }
        public Parking Parking { get; set; }

        public ParkingContract(DateTime startDatum, DateTime eindDatum, Parking parking)
        {
            StartDatum = startDatum;
            EindDatum = eindDatum;
            Parking = parking;
        }

        public bool ControleDatum(DateTime datum)
        {

            // TODO: Controleer aan de hand van reguliere expresie;
            return true;
        }
    }
}