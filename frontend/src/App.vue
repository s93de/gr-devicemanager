<template>
  <div id="app" class="ml-3 mr-3">
    <router-view></router-view>
  </div>
</template>

<script>
import axios from 'axios';
//import Dashboard from './components/Dashboard.vue';
//import Details from './components/Details';

export default {
  name: 'App',
  components: {
    //Dashboard,
    //Details
  },
  data:function(){
    return{
      detailID:15,
      machineItem:null
    }
  },
  methods:{
    load:function(){
      var url = 'http://localhost:5001/api/machine/'+this.detailID;
      axios.get(url)
      .then(resp=>this.machineItem=resp.data)
      .catch(function(){
        console.log("Can't find machine!");
      })
    }
  },
  mounted:function(){
    this.load();
  }
  
}
</script>

