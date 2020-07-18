<template>
    <div>
        <h1 class="display-3 mb-5">Probeaufgabe - Udo Schwab - 18.07.2020</h1>
        <div class="row">
            <div class="col-lg-10 ml-3" v-if="machines.length>0">
                <div class="row">
                <MachineBox v-for="machine in machines" :key="machine.machineId"  :machine="machine" @deleteMachine="deleteMachine"></MachineBox>
                </div>
            </div>
            <div class="col-lg-10 ml-3" v-else>
                <div class="alert alert-primary w-100" role="alert">
                <i class="fas fa-info-circle"></i> Keine Daten vorhanden!
                </div>
            </div>
            <div class="col-lg">
                <button type="button" class="btn btn-primary w-100" @click="showUploadPanel" v-show="!displayUploadPanel">Ger&auml;te hinzuf&uuml;gen</button>
                <button type="button" class="btn btn-secondary w-100 mb-1" @click="closeUploadPanel" v-show="displayUploadPanel">Abbrechen</button>
                <div v-show="displayUploadPanel">
                <input type="file" id="file" ref="file" class="form-control mb-5" @change="upload">
                </div>
                <button type="button" class="btn btn-secondary w-100 mt-2" @click="load">Aktualisieren</button>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios';
import MachineBox from './MachineBox.vue';

export default {
    name: 'Dashboard',
    components: {
        MachineBox
    },
    data:function(){
        return{
            machines:[],
            file:'',
            displayUploadPanel:false
        }
    },methods:{
        load:function(){
            var url = 'http://localhost:5001/api/machine';
            axios.get(url)
            .then(resp=>this.machines = resp.data)
            .catch(function(){
                console.log("Can't load machine data!");
            });
        },
        showUploadPanel:function(){
            var ele = document.getElementById('file');
            ele.value='';
            this.displayUploadPanel = true;
        },
        closeUploadPanel:function(){
            this.displayUploadPanel = false;
        },
        deleteMachine:function(id){
            var url = 'http://localhost:5001/api/machine/'+id;
            axios.delete(url)
            .then(this.load)
            .catch(function(){
                console.log("Can't delete machine!");
            });
        },
        upload:function(){
            this.displayUploadPanel=false;
            this.file = this.$refs.file.files[0];
            let formData = new FormData();
            formData.append('data',this.file);

            var url = 'http://localhost:5001/api/UploadFile';
            axios.post(url,formData)
            .then(this.load)
            .catch(function(){
                console.log("Can't upload data or process uploaded data!");
            });
        }
    },
    mounted:function(){
        this.load();
    }
}

</script>