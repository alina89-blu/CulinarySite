import { ISubscriberDetailModel } from 'src/app/interfaces/subscriber/subscriber-detail-model.interface';
import { IUpdateSubscriberModel } from 'src/app/interfaces/subscriber/update-subscriber-model.interface';

export class UpdateSubscriberModel {
  public subscriberId: number;
  public name: string;
  public email: string;

  constructor(
    public updateSubscriberModel?:
      | IUpdateSubscriberModel
      | ISubscriberDetailModel
  ) {
    if (updateSubscriberModel) {
      this.subscriberId = updateSubscriberModel.subscriberId;
      this.name = updateSubscriberModel.name;
      this.email = updateSubscriberModel.email;
    }
  }
}
