import { ISubscriberListModel } from 'src/app/interfaces/subscriber/subscriber-list-model.interface';

export class SubscriberListModel {
  public subscriberId: number;
  public name: string;
  public email: string;

  constructor(public subscriberListModel?: ISubscriberListModel) {
    if (subscriberListModel) {
      this.subscriberId = subscriberListModel.subscriberId;
      this.name = subscriberListModel.name;
      this.email = subscriberListModel.email;
    }
  }
}
