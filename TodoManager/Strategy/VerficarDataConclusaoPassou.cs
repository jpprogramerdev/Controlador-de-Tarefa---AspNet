namespace TodoManager.Strategy {
    public class VerficarDataConclusaoPassou {
        private VerficarDataConclusaoPassou() { }

        public static bool Verificar(DateTime DataParaVerificar) {
            if(DataParaVerificar <= DateTime.Now) return true;

            return false;
        }
    }
}
