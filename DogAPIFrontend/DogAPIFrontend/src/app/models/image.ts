export class Image{
  id = Number;
  url = String;
  breeds: any[] = [{
      id : Number,
      name : String,
      temperament : String,
      life_span : Number,
      weight : {
        imperial : String,
        metric: String
      },
      country_code : String,
      height : {
        imperia: String,
        metric: String
      }
  }]
}
