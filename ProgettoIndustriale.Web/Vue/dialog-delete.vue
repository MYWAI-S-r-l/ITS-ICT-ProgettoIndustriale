<template>
	<v-card class="deleteCard">
		<v-alert color="red" border="left" elevation="2" colored-border style="margin-bottom: 0px" icon="mdi-alert">
			<div style="position: absolute; right: 20px">
				<v-icon @click="onClickCancel">mdi-close</v-icon>
			</div>

			<v-card-text>
				<slot name="content"></slot>
			</v-card-text>

			<div v-if="canBeDeleted">
				<v-card-actions>Are you sure you want to remove this {{ name }}?</v-card-actions>
				<v-divider></v-divider>
				<v-card-actions class="justify-space-between">
					<v-checkbox v-model="deleteConfirmed" :label="confirmationMessage"> </v-checkbox>
					<v-progress-circular v-if="showLoading" indeterminate color="mywai" />
					<v-btn v-else color="mywai" class="white--text" :disabled="!deleteConfirmed" @click="onClickRemove">
						Delete
					</v-btn>
				</v-card-actions>
			</div>
		</v-alert>
	</v-card>
</template>

<script>
export default {
	name: "dialog-delete",
	data: function () {
		return {
			deleteConfirmed: false,
			showLoading: false
		};
	},
	props: {
		name: {
			type: String,
			default: "object"
		},
		canBeDeleted: {
			type: Boolean,
			default: true
		},
	},
	computed: {
		confirmationMessage: function () {
			return "I'm sure, let me delete this " + this.name;
		}
	},
	methods: {
		onClickCancel: function () {
			this.$emit("remove-canceled");
		},
		onClickRemove: function () {
			this.showLoading = false;
			this.deleteConfirmed = false;
			this.$emit("remove-confirmed");
		}
	}
};
</script>

<style scoped>
.deleteCard {
	margin: 0px !important;
	padding: 0px !important;
}
</style>
