import { createRouter, createWebHistory } from 'vue-router'
import VendingMachine from '../components/VendingMachine.vue'
import Coin from '../views/Coin.vue'

const routes = [
  {
    path: '/',
    component: VendingMachine
  },
  {
    path: '/:vendingname',
    component: Coin
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
