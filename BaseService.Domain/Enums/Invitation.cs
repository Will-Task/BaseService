namespace BaseService.Enums;

public enum Invitation
{
    Pending = 1,       // 還在等待回應
    Accepted,      // 已接受
    Declined,      // 已拒絕
    Canceled,      // 已取消
}