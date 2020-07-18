import Vue from 'vue'
import VueRouter from 'vue-router'
import App from './App.vue'

Vue.use(VueRouter);
Vue.config.productionTip = false;

import Dashboard from './components/Dashboard.vue';
import Details from './components/Details.vue';

const router = new VueRouter({
  routes:[
    {
      path:'/',
      component:Dashboard
    },
    {
      path:'/details/:id',
      component:Details,
      name:'Details',
      props:true
    }
  ]
})

new Vue({
  render: h => h(App),
  router
}).$mount('#app')
