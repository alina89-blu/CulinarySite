import { ICreateSubscriberModel } from 'src/app/interfaces/subscriber/create-subscriber-model.interface';

export class CreateSubscriberModel {
  public name: string;
  public email: string;

  constructor(public createSubscriberModel?: ICreateSubscriberModel) {
    if (createSubscriberModel) {
      this.name = createSubscriberModel.name;
      this.email = createSubscriberModel.email;
    }
  }
}
