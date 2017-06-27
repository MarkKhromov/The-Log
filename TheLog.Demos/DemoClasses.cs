namespace TheLog.Demos {
    class Data<T> { }

    class DataContainer<T1, T2> {
        public DataContainer() {
            Program.Log.ShowMessage(this, "Initialized", MessageType.Info);
        }
    }
}