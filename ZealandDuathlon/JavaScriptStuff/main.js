const url = "https://localhost:7080/api/Duathletes";
const app = Vue.createApp({
  data() {
    return {
      duathletes: [],
      idToBeDeleted: undefined,
      searchId: 0,
      age: 0,
      ageGroup: 0,
      filterAgeValue: 1,
      newDuathlete: {
        bib: 0,
        name: "",
        ageGroup: undefined,
        bike: 0,
        run: 0,
        total: undefined,
      },
    };
  },
  async mounted() {
    this.clear();
  },
  methods: {
    async getAll() {
      const response = await axios.get(url);
      this.duathletes = response.data;
    },
    clear() {
      this.duathletes = [];
    },
    async getById(searchId) {
      const newUrl = url + "/" + searchId;
      const response = await axios.get(newUrl);
      this.duathletes = response.data;
    },
    async deleteDuathlete() {
      const response = await axios.delete(url + "/" + this.idToBeDeleted);
      this.getAll();
    },
    async addDuathlete(newDuathlete) {
      if (this.age < 25) this.newDuathlete.ageGroup = 1;
      if (this.age >= 25 && this.age <= 35) this.newDuathlete.ageGroup = 2;
      if (this.age >= 36 && this.age <= 45) this.newDuathlete.ageGroup = 3;
      if (this.age > 45) this.newDuathlete.ageGroup = 4;
      const response = await axios.post(url, this.newDuathlete);
      this.newDuathlete.bib = response.data["bib"];
      this.duathletes.push(Object.assign({}, this.newDuathlete));
    },
    sortByTotalAscending() {
      this.duathletes.sort(
        (duathlete1, duathlete2) => duathlete1.total - duathlete2.total
      );
    },
    sortByTotalDescending() {
      this.duathletes.sort(
        (duathlete1, duathlete2) => duathlete2.total - duathlete1.total
      );
    },
    async filterByAgeGroup() {
      await this.getAll();
      this.duathletes = this.duathletes.filter(this.isInAgeGroup);
    },
    isInAgeGroup(obj) {
      if (obj.ageGroup === this.filterAgeValue) return true;
    }
  }
}).mount("#app");
