<template>
  <div class="">
    <group>
      <cell title="name" value="value"></cell>
    </group>
    <group>
      <cell title="description" value="value"></cell>
    </group>
    <x-button text="save" @click.native="onSaveTapped"></x-button>
  </div>
</template>

<script>
import { LoadingMixin } from "@/mixins/loading-mixin.js";
import { ToastMinxin } from "@/mixins/toast-mixin.js";

import { Group, Cell } from "vux";

export default {
  name: "AddTask",
  mixins: [LoadingMixin, ToastMinxin],
  created() {},

  mounted() {},

  methods: {
    onSaveTapped() {
      this.showLoading();
      let tobeAdd = getNewAddedTask();
      TaskService.addTask(tobeAdd, this.onTaskAdded);
    },

    onTaskAdded(e) {
      this.hideLoading();
      this.showToast("add task successfully");
      gotoList();
    },

    getNewAddedTask() {
      return {
        status: "todo",
        name: this.name,
        description: this.description,
      };
    },
  },

  data() {
    return {
      name: null,
      description: null,
      status: "Todo",
    };
  },
};
</script>

<style scoped>
</style>
