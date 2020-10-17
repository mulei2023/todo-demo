import Vue from 'vue'
import Router from 'vue-router'
import HelloWorld from '@/components/HelloWorld'
import TaskList from '@/pages/task-list.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/HelloWorld',
      name: 'HelloWorld',
      component: HelloWorld
    },  {
      path: '/',
      name: 'TaskList',
      component: TaskList
    }

  ]
})
