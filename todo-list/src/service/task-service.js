
import { BaseService   } from '@/service/base-service.js';

export class TaskService extends BaseService {
    static getTasks = function (successCallback) {
        Vue.axios.get("api/tasks/getByUser").then((response) => {
            if (response.data.Succeed){
                successCallback(response.data);
            }else{
                errorCallback();
            }
          })
     }

     static addTask = function (model,successCallback) {
        Vue.axios.post("api/tasks/addTask",model).then((response) => {
            if (response.data.Succeed){
                successCallback(response.data);
            }else{
                errorCallback();
            }
          })
     }
}