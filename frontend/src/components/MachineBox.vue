<template>
    <div class="col-lg-3">
        <div class="card border-dark mb-3 ">
            <div class="card-body">
                <span class="float-right">
                    <button type="button" class="btn btn-outline-danger" @click="deleteMachine">
                        <i class="fas fa-trash-alt"></i>
                    </button>
                </span>
                <h5 class="card-title">
                    <router-link :to="'/details/'+machine.machineId">
                        {{machine.name}}
                    </router-link>
                    </h5>
                <h6 class="card-subtitle mb-2 text-muted">{{machine.deviceTypeId}}</h6>
                <p class="card-text">
                    <b>Failsafe: </b>
                    <i class="fas fa-check" v-if="machine.failsafe"></i>
                    <i class="fas fa-times" v-else></i>
                </p>
            </div>
        </div>
    </div>
</template>
<script>
export default {
    name:'MachineBox',
    props:{
        machine: Object
    },
    methods:{
        deleteMachine:function(){
            this.$emit('deleteMachine',this.machine.machineId);
        }
    }
}
</script>