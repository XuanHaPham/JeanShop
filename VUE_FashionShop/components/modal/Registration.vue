<template>
    <div :class="[ openModal ? 'is-active' : '', 'modal' ]">
      <div class="modal-background"></div>
      <div class="modal-card">
        <header class="modal-card-head">
          <p v-if="!isUserSignedUp" class="modal-card-title">{{ modalTitle }}</p>
          <p v-if="isUserSignedUp" class="modal-card-title">{{ modalTitleRegistered }}</p>
          <button class="delete" aria-label="close" @click="closeModal"></button>
        </header>
        <form @submit="checkForm" action="#" method="post">
          <section class="modal-card-body">
            <div v-if="!isUserSignedUp">
              <div class="field">
                <p class="control has-icons-left has-icons-right">
                  <input
                    :class="[highlightFullNameWithError ? 'input is-danger' : 'input']"
                    type="text"
                    :placeholder="fullnamePlaceholder"
                    v-model="fullname"
                    
                    @keyup="checkFullNameOnKeyUp(fullname)"
                  >
                  <span class="icon is-small is-left">
                    <i class="fa fa-user-circle"></i>
                  </span>
                  <span v-if="highlightFullNameWithError !== null" class="icon is-small is-right">
                    <i :class="[highlightFullNameWithError ? 'fa fa-exclamation-circle' : 'fa fa-check']"></i>
                  </span>
                </p>
                <p v-if="highlightFullNameWithError" class="help is-danger">{{ fullnameErrorLabel }}</p>
                
              </div>
              

              <div class="field">
                <p class="control has-icons-left has-icons-right">
                  <input
                    :class="[highlightDOBWithError ? 'input is-danger' : 'input']"
                    type="date"
                    :placeholder="DOBPlaceholder"
                    v-model="DOB"
                    @keyup="checkDOBOnKeyUp(DOB)"
                  >
                  <span class="icon is-small is-left">
                  <i class="fa fa-birthday-cake"></i>
                  </span>
                  <span v-if="highlightDOBWithError !== null" class="icon is-small is-right">
                    <i :class="[highlightDOBWithError ? 'fa fa-exclamation-circle' : 'fa fa-check']"></i>
                  </span>
                </p>
                <p v-if="highlightDOBWithError" class="help is-danger">{{ DOBErrorLabel }}</p>
               
              </div>
                <div class="field">
                <p class="control has-icons-left has-icons-right">
                  <input
                    :class="[highlightPhoneWithError ? 'input is-danger ' : 'input']"
                    type="text"
                    :placeholder="phonePlaceholder"
                    v-model="phone"
                    @keyup="checkPhoneOnKeyUp(phone)"
                  >
                  <span class="icon is-small is-left">
                    <i class="fa fa-phone"></i>
                  </span>
                  <span v-if="highlightPhoneWithError !== null" class="icon is-small is-right">
                    <i :class="[highlightPhoneWithError ? 'fa fa-exclamation-circle' : 'fa fa-check']"></i>
                  </span>
                </p>
                <p v-if="highlightPhoneWithError" class="help is-danger">{{ phoneErrorLabel }}</p>
                
              </div>  


              <br/>
            <div class="field">
                <p class="control has-icons-left has-icons-right">
                  <input
                    :class="[highlightAddressWithError ? 'input is-danger ' : 'input']"
                    type="text"
                    :placeholder="addressPlaceholder"
                    v-model="address"
                    @keyup="checkAddressOnKeyUp(address)"
                  >
                  <span class="icon is-small is-left">
                    <i class="fa fa-map"></i>
                  </span>
                  <span v-if="highlightAddressWithError !== null" class="icon is-small is-right">
                    <i :class="[highlightAddressWithError ? 'fa fa-exclamation-circle' : 'fa fa-check']"></i>
                  </span>
                </p>
                <p v-if="highlightAddressWithError" class="help is-danger">{{ addressErrorLabel }}</p>
                
              </div>  

              <div class="field">
                <p class="control has-icons-left has-icons-right">
                  <input
                    :class="[highlightAddress1WithError ? 'input is-danger ' : 'input']"
                    type="text"
                    :placeholder="address1Placeholder"
                    v-model="address1"
                    @keyup="checkAddress1OnKeyUp(address1)"
                  >
                  <span class="icon is-small is-left">
                    <i class="fa fa-map"></i>
                  </span>
                  <span v-if="highlightAddress1WithError !== null" class="icon is-small is-right">
                    <i :class="[highlightAddress1WithError ? 'fa fa-exclamation-circle' : 'fa fa-check']"></i>
                  </span>
                </p>
                <p v-if="highlightAddress1WithError" class="help is-danger">{{ addressErrorLabel }}</p>
                
              </div> 
              
              <br/>
              <div class="field">
                <p class="control has-icons-left has-icons-right">
                  <input
                    :class="[highlightNameWithError ? 'input is-danger' : 'input']"
                    type="text"
                    :placeholder="namePlaceholder"
                    v-model="name"
                    @keyup="checkNameOnKeyUp(name)"
                  >
                  <span class="icon is-small is-left">
                    <i class="fa fa-user"></i>
                  </span>
                  <span v-if="highlightNameWithError !== null" class="icon is-small is-right">
                    <i :class="[highlightNameWithError ? 'fa fa-exclamation-circle' : 'fa fa-check']"></i>
                  </span>
                </p>
                <p v-if="highlightNameWithError" class="help is-danger">{{ nameErrorLabel }}</p>
              </div>

              <div class="field">
                <p class="control has-icons-left has-icons-right">
                  <input
                    :class="[highlightEmailWithError ? 'input is-danger' : 'input']"
                    type="email"
                    :placeholder="emailPlaceholder"
                    name="emailName"
                    v-model="email"
                    @keyup="checkEmailOnKeyUp(email)"
                  >
                  <span class="icon is-small is-left">
                    <i class="fa fa-envelope"></i>
                  </span>
                  <span v-if="highlightEmailWithError !== null" class="icon is-small is-right">
                    <i :class="[highlightEmailWithError ? 'fa fa-exclamation-circle' : 'fa fa-check']"></i>
                  </span>
                </p>
                <p v-if="highlightEmailWithError" class="help is-danger">{{ emailErrorLabel }}</p>
              </div>

              <div class="field">
                <p class="control has-icons-left has-icons-right">
                  <input
                    :class="[highlightPasswordWithError ? 'input is-danger' : 'input']"
                    type="password"
                    :placeholder="passwordPlaceholder"
                    v-model="password"
                    @keyup="checkPasswordOnKeyUp(password)"
                  >
                  <span class="icon is-small is-left">
                    <i class="fa fa-lock"></i>
                  </span>
                  <span v-if="highlightPasswordWithError !== null" class="icon is-small is-right">
                    <i :class="[highlightPasswordWithError ? 'fa fa-exclamation-circle' : 'fa fa-check']"></i>
                  </span>
                </p>
                <p v-if="highlightPasswordWithError" class="help is-danger">{{ passwordErrorLabel }}</p>
              </div>
              <div class="field">
                <p class="control has-icons-left has-icons-right">
                  <input
                    :class="[highlightRepeatPasswordWithError ? 'input is-danger' : 'input']"
                    type="password"
                    :placeholder="repeatPasswordPlaceholder"
                    v-model="repeatPassword"
                    @keyup="checkRepeatPasswordOnKeyUp(repeatPassword)"
                  >
                  <span class="icon is-small is-left">
                    <i class="fa fa-lock"></i>
                  </span>
                  <span v-if="highlightRepeatPasswordWithError !== null" class="icon is-small is-right">
                    <i :class="[highlightRepeatPasswordWithError ? 'fa fa-exclamation-circle' : 'fa fa-check']"></i>
                  </span>
                </p>
                <p v-if="highlightRepeatPasswordWithError" class="help is-danger">{{ notEqualErrorLabel }}</p>
              </div>
              
              
            </div>
            <div v-if="isUserSignedUp" class="level">
              <div class="level-item has-text-centered">
                <div>
                  <p class="title">Welcome {{ name }}!</p>
                  <p class="heading">Now you are a member</p>
                </div>
              </div>
            </div>
          </section>
          <footer class="modal-card-foot">
            <button v-if="!isUserSignedUp" class="button is-success">{{ primaryBtnLabel }}</button>
            <button v-if="isUserSignedUp" type="button" class="button is-info" @click="closeModal">{{ btnRegisteredLabel }}</button>
          </footer>
        </form>
      </div>
    </div>
</template>

<script>
import { isValidEmail } from '@/assets/validators';

export default {
  name: 'registration',

  data () {
    return {
      modalTitle: 'Sign up',
      modalTitleRegistered: 'Welcome ',
      primaryBtnLabel: 'Sign up',
      btnRegisteredLabel: 'Close',
      fullnamePlaceholder: 'FullName*',
      namePlaceholder: 'UserName*',
      emailPlaceholder: 'Email*',
      addressPlaceholder:'Address shipping 1*',
      address1Placeholder:'Address shipping 2*',
      passwordPlaceholder: 'Password*',
      repeatPasswordPlaceholder: 'Repeat Password*',
      DOBPlaceholder:"Birthday*",
      phonePlaceholder:"Phone Number",
      notEqualErrorLabel: 'Passwords must be equal',
      passwordErrorLabel: 'Password required',
      nameErrorLabel: 'Username required',
      fullnameErrorLabel: 'Full Name required',
      addressErrorLabel: 'Address required',
      phoneErrorLabel: 'Phone required',
      emailErrorLabel: 'Email required',
      DOBErrorLabel: 'Date of birth required',
      emailNotValidLabel: 'Valid email required',
      name: '',
      email: '',
      password: '',
      repeatPassword: '',
      address:'',
      address1:'',
      fullname:'',
      DOB:'',
      phone:'',
      highlightFullNameWithError: null,
      highlightNameWithError: null,
      highlightDOBWithError: null,
      highlightAddressWithError: null,
      highlightAddress1WithError: null,
      highlightPhoneWithError: null,
      highlightEmailWithError: null,
      highlightPasswordWithError: null,
      highlightRepeatPasswordWithError: null,
      isFormSuccess: false
    };
  },

  computed: {
    isUserSignedUp () {
      return this.$store.getters.isUserSignedUp;
    },
    openModal () {
      if (this.$store.getters.isSignupModalOpen) {
        return true;
      } else {
        return false;
      }
    }
  },

  methods: {
    closeModal () {
      this.$store.commit('showSignupModal', false);
    },
    checkForm (e) {
      e.preventDefault();

      if (this.DOB && this.fullname && this.phone && this.address && this.address1 && this.name && this.email && this.password && this.repeatPassword) {
        this.highlightEmailWithError = false;
        this.highlightPasswordWithError = false;
        this.highlightRepeatPasswordWithError= false;
        this.highlightNameWithError= false;
        this.highlightFullNameWithError= false;
        this.highlightDOBWithError=false;
        this.highlightAddressWithError=false;
        this.highlightAddress1WithError= false;
        this.highlightPhoneWithError=false;
        
        this.isFormSuccess = true;
        this.$store.commit('setUserName', this.name);
        this.$store.commit('isUserSignedUp', this.isFormSuccess);
        this.$store.commit('isUserLoggedIn', this.isFormSuccess);
      }

      if (!this.fullname) {
        this.highlightFullNameWithError = true;
      } else {
        this.highlightFullNameWithError = false;
      }

      if (!this.DOB) {
        this.highlightDOBWithError = true;
      } else {
        this.highlightDOBWithError = false;
      }

      if (!this.phone) {
        this.highlightPhoneWithError = true;
      } else {
        this.highlightPhoneWithError = false;
      }

      if (!this.address) {
        this.highlightAddressWithError = true;
      } else {
        this.highlightAddressWithError = false;
      }
      
      if (!this.address1) {
        this.highlightAddress1WithError = true;
      } else {
        this.highlightAddress1WithError = false;
      }

      if (!this.name) {
        this.highlightNameWithError = true;
      } else {
        this.highlightNameWithError = false;
      }

      if (!this.email) {
        this.highlightEmailWithError = true;

        if (this.email && !isValidEmail(this.email)) {
          this.emailErrorLabel = this.emailNotValidLabel;
        }
      } else {
        this.highlightEmailWithError = false;
      }

      if (!this.password) {
        this.highlightPasswordWithError = true;
      } else {
        this.highlightPasswordWithError = false;
      }

      if (!this.repeatPassword) {
        this.highlightRepeatPasswordWithError = true;
      } else {
        this.highlightRepeatPasswordWithError = false;
      }
    },
    checkFullNameOnKeyUp (fullnameValue) {
      if (fullnameValue) {
        this.highlightFullNameWithError = false;
      } else {
        this.highlightFullNameWithError = true;
      }
    },

    checkAddressOnKeyUp (addressValue) {
      if (addressValue) {
        this.highlightAddressWithError = false;
      } else {
        this.highlightAddressWithError = true;
      }
    },

    checkAddress1OnKeyUp (address1Value) {
      if (address1Value) {
        this.highlightAddress1WithError = false;
      } else {
        this.highlightAddress1WithError = true;
      }
    },

    checkDOBOnKeyUp (DOBValue) {
      if (DOBValue) {
        this.highlightDOBWithError = false;
      } else {
        this.highlightDOBWithError = true;
      }
    },

    checkNameOnKeyUp (nameValue) {
      if (nameValue) {
        this.highlightNameWithError = false;
      } else {
        this.highlightNameWithError = true;
      }
    },

    checkPhoneOnKeyUp (phoneValue) {
      if (phoneValue) {
        this.highlightPhoneWithError = false;
      } else {
        this.highlightPhoneWithError = true;
      }
    },

    checkEmailOnKeyUp (emailValue) {
      if (emailValue && isValidEmail(emailValue)) {
        this.highlightEmailWithError = false;
      } else {
        this.highlightEmailWithError = true;

        if (!isValidEmail (emailValue)) {
          this.emailErrorLabel = this.emailNotValidLabel;
        }
      }
    },
    checkPasswordOnKeyUp (passwordValue) {
      if (passwordValue) {
        this.highlightPasswordWithError = false;

        if (this.repeatPassword === this.password) {
          this.highlightRepeatPasswordWithError = false;
        } else {
          this.highlightRepeatPasswordWithError = true;
        }
      } else {
        this.highlightPasswordWithError = true;
      }
    },
    checkRepeatPasswordOnKeyUp (repeatPasswordValue) {
      if (repeatPasswordValue) {
        if (repeatPasswordValue === this.password) {
          this.highlightRepeatPasswordWithError = false;
        } else {
          this.highlightRepeatPasswordWithError = true;
          this.repeatPassword=false;
        }
      } else {
        this.highlightRepeatPasswordWithError = true;
      }
    }
  }
};
</script>

<style lang="scss" scoped>
.fa-exclamation-circle {
  color: red;
}
.fa-check {
  color: green;
}
</style>


