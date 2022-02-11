<template>
    <p>Выберите автомат:</p>
    <button
        class="btnStyle"
        @click="$router.push(`/${vendingmachine.idVendingMachine}`)"
        v-for="vendingmachine in vendingmachine"
        :key="vendingmachine.idVendingMachine"
    >
       {{vendingmachine.idVendingMachine}}
    </button>
</template>

<script>
import axios from "axios";

export default{
    name: "vending",
    data(){
        return{
            vendingmachine: [],
        };
    },

    methods:{
        async getvendingmachine(){
            this.vendingmachine = await (await axios.get("https://localhost/api/VendingMachines")).data;
        }

    },

    created(){
        this.getvendingmachine();
    }
}
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
</style>
