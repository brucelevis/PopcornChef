namespace PopcornChef.Game {
    public class StoveHeatSource : HeatSource {

        public void SetPower(StovePower power) {
            this.power = power.heatPerSecond;
        }

    }
}
