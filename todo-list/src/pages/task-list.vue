<template>
  <div class="">
    <div v-for="item in tasks" :key="item.Id" class="task-item">
      <div
        class="status-icon"
        v-bind:style="{ 'background-color': stausColor[item.Status] }"
      ></div>
      <div>
        <label>item.Name</label>
        <p>item.Description</p>
      </div>
    </div>
    <button></button>
  </div>
</template>

<script>
import { TaskService } from "@/service/task-service.js";
import { LoadingMixin } from "@/mixins/loading-mixin.js";

export default {
  name: "TaskList",
  mixins: [LoadingMixin],
  created() {},

  mounted() {
    this.showLoading("loading my tasks");
    TaskService.getTasks(null, this.onTasksLoaded);
  },

  methods: {
    onTasksLoaded(e) {
      this.hideLoading();
      this.tasks = e.data;
    },

    onAddBtnTapped() {
      gotoAddTaskPage();
    },
  },

  data() {
    return {
      tasks: [],
      stausColor: { Todo: "red", Inprogress: "yellow", Done: "green" },
    };
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.task-item {
  display: flex;
}

.status-icon {
  border-radius: 50%;
  width: 10px;
  height: 10px;
}
</style>
