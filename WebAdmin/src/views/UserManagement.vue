<template>
  <div>
    <div v-if="loading">
      <b-progress :value="loading? 50 : 100" :max="100" animated></b-progress>
    </div>
    <b-row v-if="!loading" class="animated fadeIn">
      <b-col :lg="12">
        <b-button class="mb-2 mr-2" @click="refresh">Refresh</b-button>
      </b-col>

      <b-col :lg="current ? 6 : 12">
        <c-table
          :table-data="items"
          :fields="fields"
          hover
          caption="Users"
          :rowClicked="rowClicked"
        ></c-table>
      </b-col>

      <b-col lg="6" v-if="current" class="animated fadeIn">
        <b-card class="card-accent-info" :header="'Detail of `' + current.Name + '`'">
          <b-form>
            <b-form-group v-for="field in fields" :key="field.key">
              <b-input-group v-if="['Status'].indexOf(field.key) === -1">
                <b-input-group-prepend>
                  <b-input-group-text>{{field.key}}</b-input-group-text>
                </b-input-group-prepend>
                <b-form-input disabled type="text" v-model="current[field.key]"></b-form-input>
              </b-input-group>
            </b-form-group>
            
            <b-form-group>
              <b-input-group-prepend>
                <b-input-group-text>Status</b-input-group-text>
                </b-input-group-prepend>
              <c-switch color="primary" variant="3d" v-model="current.Status"/>
            </b-form-group>
            <div
              class="btn-group form-actions animated fadeIn"
              v-if="!detailMessage && current.ID !== 0"
            >
              <b-button @click="update" type="submit" variant="outline-primary">Update</b-button>
              <b-button @click="remove" type="reset" variant="outline-danger">Remove</b-button>
            </div>
            <div class="form-actions animated fadeIn" v-if="!detailMessage && current.ID === 0">
              <b-button @click="add" type="submit" block variant="outline-primary">Add</b-button>
            </div>
            <div v-if="detailMessage">
              <b-button @click="hideWarning" block variant="outline-warning">{{detailMessage}}</b-button>
            </div>
          </b-form>
        </b-card>
      </b-col>
    </b-row>
  </div>
</template>

<script>
import cTable from "@/views/base/Table.vue";
import { Switch as cSwitch } from "@coreui/vue";
import { openapi, methods, routes } from "@/openapi";

export default {
  name: "tables",
  components: { cTable, cSwitch },
  data: () => {
    return {
      loading: true,
      items: [],
      current: null,
      detailMessage: "",
      fields: [
        { key: "ID", sortable: true },
        { key: "UserName", sortable: true },
        { key: "Fullname", sortable: true },
        { key: "Email", sortable: true },
        { key: "Phone" },
        { key: "Address" },
        { key: "Date of Birth", sortable: true },
        { key: "Point", sortable: true },
        { key: "Shipping Address", sortable: true },
        { key: "Status" },
      ]
    };
  },
  mounted: function() {
    this.refresh();
  },
  methods: {
    refresh: function() {
      this.loading = true;
      this.current = null;
      openapi(methods.GET, routes.USERS).then(data => {
        this.loading = false;
        this.items = data;
      });
    },
    rowClicked: function(user, i) {
      this.current = user;
    },
    hideSuccess: function() {
      setTimeout(() => {
        this.detailMessage = "";
      }, 1000);
    },
    hideWarning: function() {
      this.detailMessage = "";
    }
  }
};
</script>
