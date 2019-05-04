<template>
     <section class="section" >
    <div class="container">
			<div class="columns">
        <div class="column is-three-quarters">
      <div class="section-heading" style="text-align:center"> 
        <h3 class="title is-3" >{{ pageTitle }}</h3>
      </div>
      <br>
			<div class="field">
						<label class="label">Your name</label>
              <div class="control">
                <input
                    :class="[highlightEmailWithError ? 'input is-danger' : 'input']"
                    type="text"
                    :placeholder="namePlaceholder"
                    name="name"
                    v-model="name"
                  >
              </div>
            </div>
						<div class="field">
              <label class="label">Email</label>
              <div class="control">
                <input
                    :class="[highlightEmailWithError ? 'input is-danger' : 'input']"
                    type="email"
                    :placeholder="emailPlaceholder"
                    name="emailName"
                    v-model="email"
                  >
              </div>
            </div>
            <div class="field">
              <label class="label">Message</label>
              <div class="control">
                <textarea class="textarea" placeholder="Textarea"></textarea>
              </div>
            </div>

            <div class="field is-group	ed has-text-centered">
              <div class="control">
                <button class="button is-link is-large"><span class="icon">
                    <i class="fa fa-envelope"></i>
                  </span> 
                  <span>Submit</span></button>
              </div>
            </div>
        </div>
				
			<div class="column ">
			 <div class="section-heading" style="text-align:center"> 
        <h3 class="title is-3" >CONTACT US</h3>
      </div>
       <p style="font-size:25px">Eazy Fashion Shop</p>
       <h4>Address: Ho Chi Minh City, Viet Nam</h4>
        <h4>Phone Number: 0901456498</h4>
        <h4>Email: info@eazyshop.com</h4>
			</div>
      </div>

    </div>
  </section>

</template>

<script>
import VmProductsList from '@/components/Products';
import { getByTitle } from '@/assets/filters';
import { METHODS } from 'http';
import { isValidEmail } from '@/assets/validators';
export default {
	name: 'contact',
	data () {
    return {
      pageTitle: 'GET IN TOUCH',
      emailPlaceholder: 'Your Email',
      namePlaceholder: 'Your Name',
      highlightAddressWithError: null,
      highlightEmailWithError: null,
      emailName:'',
      name:'',
    //   noProductLabel: 'Your wishlist is empty'
    }
  },
 methods: {
    checkForm (e) {
      e.preventDefault();


      if (!this.email) {
        this.highlightEmailWithError = true;

        if (this.email && !isValidEmail(this.email)) {
          this.emailRequiredLabel = this.emailNotValidLabel;
        }
      } else {
        this.highlightEmailWithError = false;
      }
    },
    checkEmailOnKeyUp (emailValue) {
      if (emailValue && isValidEmail(emailValue)) {
        this.highlightEmailWithError = false;
      } else {
        this.highlightEmailWithError = true;

        if (!isValidEmail(emailValue)) {
          this.emailRequiredLabel = this.emailNotValidLabel;
        }
      }
    }
  }
};

</script>

<style lang="scss" scoped>
  .card {
    margin: 10px;
  }
	p{
		margin: 20px;
		margin-left: 40px; 
		font-weight: bold;
	}
	h3{
		color: palevioletred;
	}
	h4{
		margin: 20px;
	}
</style>


