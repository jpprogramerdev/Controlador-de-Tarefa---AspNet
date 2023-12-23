namespace TodoManager.Strategy {
    public class VerificarData {

        private VerificarData() { }

        public static bool verificar(DateTime DataInformada) {
            if (DataInformada < DateTime.Now) {
                return false;
            }
            return true;
        }

    }
}
