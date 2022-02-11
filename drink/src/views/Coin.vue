<template>
  <div class="wrap">
    <label></label>
    <div>
      <button
        class="btnStyle"
        v-for="drink in drink"
        :key="drink.idDrink"
        @click="outMoney(drink)"
      >
        <img height="100" :src="getOutput(drink.image)" alt="none image" />
        <br />
        <label style="font-size: 25px">{{ drink.name }}</label>
        <br />
        <label style="font-size: 25px">{{ drink.cost }} руб.</label>
      </button>
    </div>
    <div class="coins" id="coinsAdd">
      <button
        class="btnCoinStyle"
        @click="getMoney(coin)"
        v-for="coin in coin"
        :key="coin.idCoin"
      >
        {{ coin.denomination }}
      </button>
      <p>Денег всего: {{ counter }}</p>
      <button @click="getCash()">
        Получить сдачу
      </button>
    </div>
  </div>
</template>





<script>
import axios from "axios";

export default {
  name: "app",
  data() {
    return {
      drink: [],
      coin: [],
      machinecoin: [],
      machinedrink: [],
      counter: 0,
    };
  },

  methods: {
    async getData() {
      this.getCoins();
      const machinecoin = await axios.get(
        "https://localhost/api/VendingMachineCoins"
      );
      this.machinecoin = machinecoin.data.filter(
        (x) => x.idVendingMachine == this.$route.params.vendingname
      );

      const machinedrink = await axios.get(
        "https://localhost/api/VendingMachineDrinks"
      );

      this.machinedrink = machinedrink.data.filter(
        (x) => x.idVendingMachine == this.$route.params.vendingname
      );

      const drink = await axios.get("https://localhost/api/Drinks");
      this.drink = drink.data.filter((x) =>
        this.machinedrink.some((y) => y.drinksId == x.idDrink)
      );
    },

    async getCoins() {
      const coin = await axios.get("https://localhost/api/Coins");
      this.coin = coin.data;
    },

    async getCash(){
      const outCash = this.machinecoin.filter((x)=>x.count>0);
      const cash = this.coin.filter((x)=> 
        outCash.some((y)=>y.idCoin=x.idCoin)
      );
      cash.reverse();

      for(let i=0;i<cash.length;i++){
        const parseCoin = parseInt(cash[i].denomination);

        if (this.counter <= 0 && parseCoin>this.counter){
          continue;
        }

        const findCoin = outCash.find((x)=>x.idCoin==cash[i].idCoin);
        const resultMin = Math.floor(
          Math.min(findCoin.count, this.counter/parseCoin)
        );

        if (findCoin.count>=resultMin&&this.counter%parseCoin>0){
          resultMin -= 1;
        }

        this.counter-= resultMin* parseCoin;
        const resultCoins = this.machinecoin.find((x)=>x.idCoin==cash[i].idCoin);

        resultCoins.count -= resultMin;
        console.log(resultCoins);
        await axios.put(
          `https://localhost/api/VendingMachineCoins/${resultCoins.idVendingMachineCoins}`,
          resultCoins
        );
      }
    },

    async getMoney(coin) {
      this.counter += parseInt(coin.denomination);
      const addcoin = this.machinecoin.find((x) => x.idCoin == coin.idCoin);
      console.log(addcoin);
      addcoin.count += 1;
      await axios.put(
        `https://localhost/api/VendingMachineCoins/${addcoin.idVendingMachineCoins}`,
        addcoin
      );
    },

    async outMoney(drink) {
      if (drink.cost <= this.counter) {
        this.counter -= parseInt(drink.cost);
        const adddrink = this.machinedrink.find(
          (x) => x.drinksId == drink.idDrink
        );
        adddrink.count -= 1;
        console.log(adddrink);
        await axios.put(
          `https://localhost/api/VendingMachineDrinks/${adddrink.idVendingMachineDrinks}`,
          adddrink
        );
      } else {
        alert("Недостаточно средств");
      }
    },

    getOutput(image) {
      return (
        "data:image;base64," + (image === null ? "" : image.toString("base64"))
      );
    },
  },
  mounted() {
    this.getData();
  },
};
</script>





<style lang="scss">
.btnStyle {
  height: 200px;
  width: 200px;
  margin-top: 15px;
  margin-left: 20px;
  border: 6px solid purple double;
  border-radius: 12px;
}

.btnCoinStyle {
  height: 100px;
  width: 100px;
  margin-top: 15px;
  margin-left: 20px;
}

.coins {
  width: 260px;
  justify-content: right;
  align-items: right;
  margin-left: 30px;
}

.wrap {
  border: 3px solid black;
  border-radius: 12px;
  width: 100%;
  height: 100%;
  min-height: 500px;
  max-width: 1200px;
  display: flex;
  justify-content: center;
  align-items: center;
  align-content: center;
}
</style>

