<template>
    <div>
        <div class="mt-2 mb-3">
            <h1 class="is-inline">{{machineItem.name}}</h1>
            <h2 class="ml-2 text-muted is-inline">{{machineItem.deviceTypeId}}</h2>
            <router-link class="btn btn-secondary is-inline float-right" to="/">
                <i class="fas fa-arrow-left"></i> Back
            </router-link>
        </div>
        <table class="table table-striped">
            <tr>
                <th scope="row">Failsafe</th>
                <td>{{machineItem.failsafe |JaNein}}</td>
            </tr>
            <tr>
                <th scope="row">Temperature</th>
                <td>{{machineItem.tempMin}} - {{machineItem.tempMax}} &deg;C</td>
            </tr>
            <tr>
                <th scope="row">Einbauposition</th>
                <td>{{machineItem.installationPosition |FirstCharUpperCase}}</td>
            </tr>
            <tr>
                <th scope="row">Geeignet f&uuml;r 19" Schrank</th>
                <td>{{machineItem.insertInto19InchCabinet |JaNein}}</td>
            </tr>
            <tr v-if="machineItem.terminalElement!=null">
                <th scope="row">Terminal vorhanden</th>
                <td>{{machineItem.terminalElement |JaNein}}</td>
            </tr>
            <tr v-if="machineItem.advancedEnvironmentalConditions!=null">
                <th scope="row">Erweiterte Umgebungsbedingungen</th>
                <td>{{machineItem.advancedEnvironmentalConditions |JaNein}}</td>
            </tr>
        </table>
    </div>
</template>

<script>
import axios from 'axios';
export default {
    name:'Details',
    props:{
        id:Number
    },
    data:function(){
        return{
            machineItem:null
        }
    },
    filters:{
        JaNein:function(value){
            if(value==true){
                return "Ja";
            }else{
                return "Nein";
            }
        },
        FirstCharUpperCase:function(value){
            return value.charAt(0).toUpperCase() + value.slice(1);
        }
    },
    methods:{
        load: function (){
            var url = 'http://localhost:5001/api/machine/'+this.id;
            axios.get(url)
            .then(resp=>this.machineItem=resp.data)
            .catch(function(){
                console.log("Can't find data");
            })
        }
    },
    mounted:function(){
        this.load();
    }
}
</script>

<style scoped>
.is-inline{
    display: inline;
}
</style>